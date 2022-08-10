param location string = resourceGroup().location
param tfBackendStorageAccountName string
param tfBackendContainerName string 

// tf state - storage account

resource storageAccount 'Microsoft.Storage/storageAccounts@2021-06-01' = {
  name: tfBackendStorageAccountName
  location: location
  sku: {
    name: 'Standard_LRS'
  }
  kind: 'StorageV2'
  properties: {
    accessTier: 'Hot'
  }
}

resource container 'Microsoft.Storage/storageAccounts/blobServices/containers@2019-06-01' = {
  name: '${storageAccount.name}/default/${tfBackendContainerName}'
}

// storage account containers (1 per environment)


// Azure container registry 
