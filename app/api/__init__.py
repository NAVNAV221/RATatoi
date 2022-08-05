from flask import Blueprint

api_blueprint = Blueprint('api', __name__)

from app.api import clients_status
from app.api import wmi_action
