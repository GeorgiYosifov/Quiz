Quiz application

Get code from github:
git clone https://github.com/GeorgiYosifov/Quiz.git

Download Docker.
Run the application with docker.
Go to "Quiz" directory and run:

docker-compose up
docker-compose up --build (When you did modifications in the existing code)

In case when "web-server" container isn't running, try to run it manually or with command:

docker start web-server

If in this way doesn't work, try whole procedure again.