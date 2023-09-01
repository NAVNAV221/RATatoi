from server.app import app
from flask import render_template


@app.route('/clients/assign_wmi_action/', methods=['GET'])
def assign_action():
    return render_template("assign_client_action.html", title="Assign Action")
