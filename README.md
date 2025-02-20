# Event-Driven Architecture PoC with Apache Kafka

## Overview
This Proof of Concept (PoC) demonstrates a simple Event-Driven Architecture (EDA) using Apache Kafka as the event broker and .NET for building the producer and consumer applications. The goal of this project is to showcase how events can be produced, consumed, and processed in a decoupled system, enabling scalable and resilient communication between components.

## Key Features

### Producer Application:

- Generates events (e.g., OrderCreated) and sends them to a Kafka topic.  
- Simulates a real-world scenario where events are produced by a service (e.g., an e-commerce platform).  

### Consumer Application:

- Listens to the Kafka topic and processes incoming events.  
- Demonstrates how downstream services can react to events in real-time.

### Apache Kafka:

- Acts as the central event broker, ensuring reliable message delivery and decoupling producers from consumers.

## Why This PoC?
- **Decoupling:** Producers and consumers are independent, allowing for flexible and scalable system design.  
- **Real-Time Processing:** Events are processed as they occur, enabling real-time responsiveness.  
- **Scalability:** Kafka's distributed nature allows for horizontal scaling of both producers and consumers.  
- This PoC serves as a foundation for building more complex event-driven systems, such as microservices architectures, real-time data pipelines, or event sourcing implementations.  

## Prerequisites
- **.NET SDK:** Ensure you have the .NET SDK installed. Download it from here.

- **Docker:** Install Docker to run Kafka and Zookeeper. Download Docker from here.

- **Confluent.Kafka Library:** The project uses the Confluent.Kafka NuGet package for Kafka integration.
