variable "location" {
    type = string
}
variable "location_short_code" {
    type = string
}
variable "service" {
    type = string
}
variable "unit" {
    type = string
}
variable "environment" {
    type = string
}
variable "skuTier" {
  type = string
  description = "sku tier for app service plan"
  default = "Standard"
}
