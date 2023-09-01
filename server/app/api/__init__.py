from flask import Blueprint

api_blueprint = Blueprint('api', __name__)

from server.app.api import clients_status
from server.app.api import wmi_action
