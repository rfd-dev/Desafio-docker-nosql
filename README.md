# Desafio-docker-nosql

Para iniciar os containeners
docker compose up -d --build

Para executar o teste de carga
cd k6
k6 run k6-script.js --out json=testresult.json