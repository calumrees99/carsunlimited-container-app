### Navigate to the service Directory
- in a cmd prompt run a `cd` command to the terraform path:
 `carsunlimited-container-app/deploy/infrastructure/inventoryapi`

### For dev testing
- run `terraform init -backend-config="key=dev/inventoryapi.tfstate" -reconfigure`
- run `terraform plan -var-file="tfvars\dev.tfvars"`

### For qa testing
- run `terraform init -backend-config="key=qa/inventoryapi.tfstate" -reconfigure` 
- run `terraform plan -var-file="tfvars\qa.tfvars"`

### For stage testing
- run `terraform init -backend-config="key=stg/inventoryapi.tfstate" -reconfigure` 
- run `terraform plan -var-file="tfvars\stg.tfvars"`

### For prod testing
- run `terraform init -backend-config="key=prd/inventoryapi.tfstate" -reconfigure`
- run `terraform plan -var-file="tfvars\prd.tfvars"`