#!/bin/sh

# Check if the container exists
if docker ps -aqf name=cardsapi >/dev/null 2>&1; then
    docker stop cardsapi
    docker rm cardsapi
fi

# Build the Docker image
docker build -t cardsapi .

# Run the Docker container
docker run --name cardsapi -p 8000:8000 --user appuser -d --restart always cardsapi
