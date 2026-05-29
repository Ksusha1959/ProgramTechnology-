import os
import psycopg2
from dotenv import load_dotenv

# 1. Загружаем переменные из файла .env
load_dotenv()

def connect_to_db():
    try:
        # 2. Берем параметры подключения из окружения
        connection = psycopg2.connect(
            host=os.getenv("DB_HOST"),
            port=os.getenv("DB_PORT"),
            database=os.getenv("DB_NAME"),
            user=os.getenv("DB_USER"),
            password=os.getenv("DB_PASSWORD")
        )
        print("✅ Успешное подключение к PostgreSQL!")
        return connection
    except Exception as error:
        print(f"❌ Ошибка при подключении: {postgreSQL_error}")
        return None

def get_books():
    conn = connect_to_db()
    if conn:
        cur = conn.cursor()
        # 3. Выполняем SQL запрос к базе
        cur.execute("SELECT title, language FROM books;")
        books = cur.fetchall()
        
        print("\n--- Список книг в библиотеке ---")
        for book in books:
            print(f"Название: {book[0]} | Язык: {book[1]}")
        
        cur.close()
        conn.close()

if __name__ == "__main__":
    get_books()
