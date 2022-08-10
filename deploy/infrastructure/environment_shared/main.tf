
###############################################################################
# Locals
###############################################################################

locals {
  resource_prefix              = "${var.unit}-${var.service}-${var.environment}-${var.location_short_code}"
  resource_prefix_no_separator = "${var.unit}${var.service}${var.environment}${var.location_short_code}"
}

###############################################################################
# DATA 
###############################################################################

data "azurerm_container_registry" "data_acr" {
  name                = "csrcarsshareduksacr"
  resource_group_name = "csr-cars-shared-uks-rg"
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
# Managed Identity
###############################################################################

resource "azurerm_user_assigned_identity" "uami" {
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  name                = "${local.resource_prefix}-id"
}

## Allow AcrPull access to ACR
resource "azurerm_role_assignment" "aks_to_acr_role" {
  scope                            = data.azurerm_container_registry.data_acr.id
  role_definition_name             = "AcrPull"
  principal_id                     = azurerm_user_assigned_identity.uami.principal_id
}

###############################################################################
# Container App Environment
###############################################################################

resource "azapi_resource" "cae" {
  type = "Microsoft.App/managedEnvironments@2022-03-01"
  name = "${local.resource_prefix}-cae"
  location = azurerm_resource_group.rg.location
  parent_id = azurerm_resource_group.rg.id

}