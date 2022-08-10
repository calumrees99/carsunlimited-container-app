terraform {
  required_version = "~> 1.0.11"
  required_providers {
    azurerm = {
      source = "hashicorp/azurerm"
      version = "2.93.1"
    }
  }
  
  backend "azurerm" {
    resource_group_name  = "csr-cars-tfstate-uks-rg"  # must match the pipeline variable: resource_group_tfstate
    container_name       = "tfstate" # must match the pipeline variable: backendAzureRmContainerName
    storage_account_name = "csrcarstfstate" # must macth the pipeline variable: storageAccountName

  }
}

provider "azurerm" {
  # Configuration options
  features { }
}