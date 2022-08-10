### Navigate to the service Directory
- in a cmd prompt run a `cd` command to the path `Carsunlimited/infrastructure/environment_shared`

### For dev testing
- run `terraform init -backend-config="key=dev/environment_shared.tfstate" -reconfigure`
- run `terraform plan -var-file="tfvars\dev.tfvars"`

### For qa testing
- run `terraform init -backend-config="key=qa/environment_shared.tfstate" -reconfigure` 
- run `terraform plan -var-file="tfvars\qa.tfvars"`

### For stage testing
- run `terraform init -backend-config="key=stg/environment_shared.tfstate" -reconfigure` 
- run `terraform plan -var-file="tfvars\stg.tfvars"`

### For prod testing
- run `terraform init -backend-config="key=prd/environment_shared.tfstate" -reconfigure`
- run `terraform plan -var-file="tfvars\prd.tfvars"`