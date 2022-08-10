package main

import (
	"carsunlimited-purchase-api/controllers"
	"net/http"

	"github.com/gin-contrib/cors"
	"github.com/gin-gonic/gin"
)

func main() {

	router := gin.Default()

	router.GET("/", func(c *gin.Context) {
		c.Status(http.StatusNoContent)
	})

	router.POST("/api/purchase/:id", controllers.CompletePurchase)

	router.Use(cors.Default())
	router.Run()
}
