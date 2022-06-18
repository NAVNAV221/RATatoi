from app import app
from flask import render_template, flash, redirect
from app.forms import RegisterWMIAction, AssignClientAction
from app.validators import is_wmi_class, is_wmi_scope
from app.models import WMIAction, Client


# TODO: Save WMI action from the user input
@app.route('/clients/register_wmi_action/', methods=['GET', 'POST'])
def register():
    form = RegisterWMIAction()
    if form.validate_on_submit():
        if not is_wmi_class(form.wmi_class):
            flash("Invalid WMI class")
        flash("WMI Action registered")
    return render_template('action_register.html', title="Register WMI Action", form=form)


@app.route('/clients/assign_wmi_action/', methods=['GET', 'POST'])
def assign_action():
    form = AssignClientAction()
    if form.is_submitted():
        input_wmi_action_id = str(form.wmi_actions_opts.data).split('|')[0].strip()
        input_client_id = str(form.client_id_opts.data).split('|')[0].strip()

        client = Client.query.filter_by(id=input_client_id).first()
        wmi_action = WMIAction.query.filter_by(id=input_wmi_action_id).first()

        if client is None or wmi_action is None:
            flash("Invalid client id or wmi_action")
            return "<html><h1>Choose action from the list please!</h1></html>"

        client.set_wmi_action(wmi_action)

    return render_template("assign_client_action.html", title="Assign Action", form=form)
