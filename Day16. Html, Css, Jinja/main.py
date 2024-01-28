from flask import Flask, render_template


app = Flask(__name__)


@app.route("/")
def index():
    return render_template('base.html')


@app.route("/info")
def info():
    return render_template('about.html')


@app.route("/calc/<int:x>/<int:y>")
def calc(x, y):
    return f'{x} + {y} = {x + y}'


@app.route("/stud")
def stud():
    list_students = ["Елена Свиридова", "Терновая Ольга", "Султан Ситдыков",
                     "Анастасия Савозькина", "Игорь Трофимов", "Сергей Никитин", 
                     "Олег Елагин"]
    return render_template('students.html', title="Список студентов",
                           list_students=list_students)


if __name__ == '__main__':
    app.run()


# http://127.0.0.1:5000/ -> main.py -> base.html
# http://127.0.0.1:5000/info -> main.py -> about.html