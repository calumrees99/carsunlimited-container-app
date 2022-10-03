
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
# Container App Environment
###############################################################################

resource "azapi_resource" "cae" {
  type = "Microsoft.App/managedEnvironments@2022-03-01"
  name = "${local.resource_prefix}-cae"
  location = azurerm_resource_group.rg.location
  parent_id = azurerm_resource_group.rg.id

}