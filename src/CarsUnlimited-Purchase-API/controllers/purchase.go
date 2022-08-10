package controllers

import (
	"carsunlimited-purchase-api/appsettings"
	"carsunlimited-purchase-api/models"
	"encoding/json"
	"fmt"
	"github.com/gin-gonic/gin"
	"github.com/streadway/amqp"
	"log"
	"net/http"
)

type AppSettings struct {
	ServiceBusConnectionString string
}

func failOnError(err error, msg string) {
	if err != nil {
		log.Fatalf("%s: %s", msg, err)
	}
}

// POST /purchase/:id
// Complete the purchase
func CompletePurchase(c *gin.Context) {

	settings := AppSettings{}

	// filling the variable with the settings file and env vars
	if err := appsettings.ReadFromFileAndEnv(&settings); err != nil {
		panic(err)
	}

	var id = c.Param("id")

	message := models.Message{
		SessionId: id,
	}

	msg, err := json.Marshal(message)

	if err != nil {
		fmt.Println(err)
		return
	}

	conn, err := amqp.Dial(settings.ServiceBusConnectionString)
	failOnError(err, "Failed to connect to RabbitMQ")
	defer conn.Close()

	ch, err := conn.Channel()
	failOnError(err, "Failed to open a channel")
	defer ch.Close()

	q, err := ch.QueueDeclare(
		"cmd-cart", // name
		false,   // durable
		false,   // delete when unused
		false,   // exclusive
		false,   // no-wait
		nil,     // arguments
	)
	failOnError(err, "Failed to declare a queue")

	err = ch.Publish(
		"",     // exchange
		q.Name, // routing key
		false,  // mandatory
		false,  // immediate
		amqp.Publishing{
			ContentType: "text/json",
			Body:        []byte(msg),
		})
	failOnError(err, "Failed to publish a message")
	log.Printf(" [x] Sent %s", msg)

	c.JSON(http.StatusOK, gin.H{"data": msg})
}