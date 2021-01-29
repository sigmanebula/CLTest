# CLTest
## Установка
Для того установки потребуется:
1. Скачать докер-образ базы MS Sql
   ```powershell
   docker pull mcr.microsoft.com/mssql/server
   ```
2. Запустить со следующими настройками:
   ```
   docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=GDc6GlPQTNMSLPOwNQil' -p 1433:1433 -d mcr.microsoft.com/mssql/server:latest
   ```
3. Затем с помощью SMSS подключиться к базе данных и выполнить скрипты `CreaeteDataBase.sql` и `CreateTable.sql`.
4. Запустить solution.
