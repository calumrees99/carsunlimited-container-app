
###############################################################################
# Locals
###############################################################################

locals {
  resource_prefix              = "${var.unit}-${var.service}-${var.environment}-${var.location_short_code}"
  resource_prefix_no_separator = "${var.unit}${var.service}${var.environment}${var.location_short_code}"
}

###############################################################################
# RG 
###############################################################################

resource "azurerm_resource_group" "rg" {
  name     = "${local.resource_prefix}-rg"
  location = var.location

  tags = {
    service     = var.service
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

data "azurerm_user_assigned_identity" "data_uami" {
  resource_group_name = "$csr-shared-${environment}-uks-rg"
  name                = "csr-shared-${environment}-uks-id"
}

###############################################################################
# Container App
###############################################################################

resource "azapi_resource" "app" {
  type = "Microsoft.App/containerApps@2022-03-01"
  name = "${local.resource_prefix}-app"
  location = azurerm_resource_group.rg.location
  parent_id = azurerm_resource_group.rg.id
  identity {
    type = "string"
    identity_ids = [data.azurerm_user_assigned_identity.data_uami.id]
  }
  body = jsonencode({
    properties = {
      configuration = {
        activeRevisionsMode = "string"
        dapr = {
          appId = "${local.resource_prefix}-app"
          appPort = 3000
          appProtocol = "http"
          enabled = true
        }
        ingress = {
          allowInsecure = true
          external = bool
          targetPort = 80
          transport = "string"
        }
        registries = [
          {
            identity = data.azurerm_container_registry.data_acr.id
            passwordSecretRef = data.azurerm_container_registry.data_acr.admin_password
            server = data.azurerm_container_registry.data_acr.login_server
            username = data.azurerm_container_registry.data_acr.admin_username
          }
        ]
        secrets = [
          {
            name = "string"
            value = "string"
          }
        ]
      managedEnvironmentId = data.azapi_resource.data_cae.id

      template = {
        containers = [
          {
            image = "csrcarsshareduksacr.azurecr.io/${service}:${tag}"
            name = "${service}"
            args = [
              "string"
            ]
            command = [
              "string"
            ]
            env = [
              {
                name = "string"
                secretRef = "string"
                value = "string"
              }
            ]
          }
        ]
        revisionSuffix = "string"
      }
     }
    }
  })
}

