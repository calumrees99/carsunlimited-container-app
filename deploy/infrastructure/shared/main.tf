
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
# ACR
###############################################################################

resource "azurerm_container_registry" "acr" {
  name                = "${local.resource_prefix_no_separator}acr"
  resource_group_name = azurerm_resource_group.rg.name
  location            = azurerm_resource_group.rg.location
  sku                 = "${var.skuTier}"
  admin_enabled       = false
}

###############################################################################
# Any Other Resources i.e Shared Key-vaults, Storage accounts e.t.c
###############################################################################