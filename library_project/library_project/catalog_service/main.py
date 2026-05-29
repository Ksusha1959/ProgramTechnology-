from fastapi import FastAPI, Depends, HTTPException
from sqlalchemy.orm import Session
from . import models, database

app = FastAPI(title="Library API")

# Создаем таблицы в базе при запуске
models.Base.metadata.create_all(bind=database.engine)

@app.post("/books/")
def create_book(title: str, author: str, isbn: str, db: Session = Depends(database.get_db)):
    db_book = models.Book(title=title, author=author, isbn=isbn)
    db.add(db_book)
    db.commit()
    db.refresh(db_book)
    return db_book

@app.get("/books/")
def list_books(db: Session = Depends(database.get_db)):
    return db.query(models.Book).all()

@app.get("/books/{isbn}")
def get_book(isbn: str, db: Session = Depends(database.get_db)):
    book = db.query(models.Book).filter(models.Book.isbn == isbn).first()
    if not book:
        raise HTTPException(status_code=404, detail="Книга не найдена")
    return book