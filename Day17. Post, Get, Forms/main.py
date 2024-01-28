from flask import Flask, render_template, url_for, redirect
from register_form import RegisterForm
from auth_form import AuthForm


app = Flask(__name__)
app.config['SECRET_KEY'] = 'hello, hello, hello'


@app.route("/")
def index():
    return render_template('base.html')


@app.route("/info")
def info():
    return render_template('about.html')


@app.route("/calc/<int:x>/<int:y>")
def calc(x, y):
    return f'{x} + {y} = {x + y}'


@app.route("/stud") # GET
def stud():
    list_students = ["Елена Свиридова", "Терновая Ольга", "Султан Ситдыков",
                     "Анастасия Савозькина", "Игорь Трофимов", "Сергей Никитин", 
                     "Олег Елагин"]
    return render_template('students.html', title="Список студентов",
                           list_students=list_students)


@app.route('/register', methods=['GET', "POST"])
def reg():
    form = RegisterForm()
    if form.validate_on_submit():
        print(form.data)
        return redirect('/')
    return render_template("register.html", form=form)


@app.route('/auth', methods=['GET', 'POST'])
def auth():
    form = AuthForm()
    if form.validate_on_submit():
        # return redirect(url_for('info'))
        return redirect('/')
    return render_template('auth.html', form=form)


if __name__ == '__main__':
    app.run(port=8000)


# http://127.0.0.1:5000/ -> main.py -> base.html
# http://127.0.0.1:5000/info -> main.py -> about.html