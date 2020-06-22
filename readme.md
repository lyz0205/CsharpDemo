# Kafka Demo with Landoop
Here's a simple demo of a producer and consumer for Kafka.

## Blog Post
[mrjamiebowman.com: Getting Started with Landoop Kafka on Docker Locally](https://www.mrjamiebowman.com/software-development/getting-started-with-landoop-kafka-on-docker-locally/)

## Staring Kafka Locally with Docker
docker pull landoop/fast-data-dev
	
docker run -d --name landoopkafka -p 2181:2181 -p 3030:3030 -p 8081:8081 -p 8082:8082 -p 8083:8083 -p 9092:9092 -e ADV_HOST=127.0.0.1 landoop/fast-data-dev

docker logs -f landoopkafka

Once it's running you can access the dashboard here... [Landoop's Kafka UI](http://127.0.0.1:3030/)

### Accessing Docker Container with Bash
docker exec -it landoopkafka bash
