CREATE USER 'root'@'%' IDENTIFIED WITH  mysql_native_password BY 'root';
GRANT ALL PRIVILEGES ON *.* TO 'root'@'%';
FLUSH PRIVILEGES;