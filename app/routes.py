from app import app
from flask import render_template
from app.forms import AssignClientAction


@app.route('/clients/register_wmi_action/')
def register():
    form = AssignClientAction()
    render_template('action_register.html', form=form)
