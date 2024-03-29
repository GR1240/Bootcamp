from flask_wtf import FlaskForm
from wtforms import StringField, SubmitField, EmailField, PasswordField
from wtforms.validators import DataRequired


class AuthForm(FlaskForm):
    name = StringField("Имя пользователя: ", validators=[DataRequired()])
    password = PasswordField("Пароль: ", validators=[DataRequired()])
    submit = SubmitField("Войти")
