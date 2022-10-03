
###############################################################################
# Locals
###############################################################################

locals {
  resource_prefix              = "${var.unit}-${var.project}-${var.service}-${var.environment}-${var.location_short_code}"
  resource_prefix_no_separator = "${var.unit}${var.project}${var.service}${var.environment}${var.location_short_code}"
}

###############################################################################
# RG 
###############################################################################

resource "azurerm_resource_group" "rg" {
  name     = "${local.resource_prefix}-rg"
  location = var.location

  tags = {
    project     = var.project
    environment = var.environment
    location    = var.location
  }
}

###############################################################################
# DATA 
###############################################################################

data "azurerm_container_registry" "data_acr" {
  name                = "csrcarsshareduksacr"
  resource_group_name = "csr-cars-shared-uks-rg"
}

data "azapi_resource" "data_cae" {
  type = "Microsoft.App/managedEnvironments@2022-03-01"
  name = "$csr-shared-${environment}-uks-cae"
  parent_id = "csr-shared-${environment}-uks-rg"
}

###############################################################################
# Managed Identity
###############################################################################

resource "azurerm_user_assigned_identity" "uami" {
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  name                = "${local.resource_prefix}-id"
}

## Allow AcrPull access to ACR
resource "azurerm_role_assignment" "role_acr_pull" {
  scope                            = data.azurerm_container_registry.data_acr.id
  role_definition_name             = "AcrPull"
  principal_id                     = azurerm_user_assigned_identity.uami.principal_id
}

###############################################################################
# Container App
###############################################################################

resource "azapi_resource" "app_mongo_db" {
  type = "Microsoft.App/containerApps@2022-03-01"
  name = "${local.resource_prefix}-app"
  location = azurerm_resource_group.rg.location
  parent_id = azurerm_resource_group.rg.id
  identity {
    type = "UserAssigned"
    identity_ids = [azurerm_user_assigned_identity.uami.id]
  }
  body = jsonencode({
    properties = {
      configuration = {
        dapr = {
          appId = "inventorydb"
          appPort = 27017
          appProtocol = "http"
          enabled = true
        }
        ingress = {
          external = false
          targetPort = 27017
        }
        registries = [
          {
            identity = data.azurerm_container_registry.data_acr.id
            passwordSecretRef = data.azurerm_container_registry.data_acr.admin_password
            server = data.azurerm_container_registry.data_acr.login_server
            username = data.azurerm_container_registry.data_acr.admin_username
          }
        ]
      managedEnvironmentId = data.azapi_resource.data_cae.id
      template = {
        containers = [
          {
            image = "csrcarsshareduksacr.azurecr.io/inventorydb:${tag}"
            name = "inventorydb"
          }
        ]
        revisionSuffix = "${tag}"
      }
     }
    }
  })
}
