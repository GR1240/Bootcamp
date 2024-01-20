from flask import Flask


app = Flask(__name__)


@app.route("/") # главная страница
def index():
    return "Hellow, world!"

@app.route("/info") # info страница
def info():
    return "Меня создала компания GeekBrains!"

if __name__ == "__main__":
    app.run()