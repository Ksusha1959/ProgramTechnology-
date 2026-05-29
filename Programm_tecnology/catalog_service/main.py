from fastapi import FastAPI, Depends, HTTPException
from sqlalchemy.orm import Session
from . import models, database
from pydm import Base

app = FastAPI(title="Library Catalog Service")

# Создание таблиц при запуске
models.Base.metadata.create_all(bind=database.engine)

@app.post("/books/")
def create_book(title: str, author: str, isbn: str, db: Session = Depends(database.get_db)):
    db_book = models.Book(title=title, author=author, isbn=isbn)
    db.add(db_book)
    db.commit()
    db.refresh(db_book)
    return db_book

@app.get("/books/")
def read_books(skip: int = 0, limit: int = 10, db: Session = Depends(database.get_db)):
    books = db.query(models.Book).offset(skip).limit(limit).all()
    return books

@app.get("/books/{isbn}")
def get_book(isbn: str, db: Session = Depends(database.get_db)):
    book = db.query(models.Book).filter(models.Book.isbn == isbn).first()
    if not book:
        raise HTTPException(status_code=404, detail="Book not found")
    return book
