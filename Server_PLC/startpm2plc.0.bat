@echo off

TIMEOUT 5

cd C:\Server_PLC
pm2 start Server.js
-1