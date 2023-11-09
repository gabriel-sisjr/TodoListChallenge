aws ecr get-login-password --region us-east-1 | docker login --username AWS --password-stdin 315249046228.dkr.ecr.us-east-1.amazonaws.com
docker build -t todolistchallenge .
docker tag todolistchallenge:latest 315249046228.dkr.ecr.us-east-1.amazonaws.com/todolistchallenge:latest
docker push 315249046228.dkr.ecr.us-east-1.amazonaws.com/todolistchallenge:latest