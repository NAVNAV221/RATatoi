from app.api import api_blueprint
from app.models import Client, WMIAction
from flask import jsonify, request, render_template


@api_blueprint.route('/wmi-action-search', methods=['POST'])
def wmi_action_search():
    """
    Api that server for wmi actions search.
    :return:
    """
    search_word = f'%{request.form["query"]}%'
    wmi_action_result = WMIAction.query.filter(WMIAction.wmi_class.like(search_word)).all()
    return jsonify({'htmlresponse': render_template('wmi_action_search_table.html', wmi_actions=wmi_action_result)})


@api_blueprint.route('/clients_modal', methods=['GET'])
def present_require_client_id_modal():
    """
    return a client modal content with a user's list.
    :return:
    """
    clients = Client.query.all()
    return jsonify({'htmlresponse': render_template('client_modal_content.html', clients=clients)})


@api_blueprint.route('/assign_wmi_action_to_user', methods=['POST'])
def assign_wmi_action_to_user():
    """
    Get client_id and wmi_action_id and assign wmi action to client.
    :return:
    """
    client_id = request.form['client_id']
    wmi_action_id = request.form['wmi_action_id']

    original_client = Client.query.filter_by(id=client_id).first()
    original_wmi_action = WMIAction.query.filter_by(id=wmi_action_id).first()

    if original_client and original_wmi_action:
        original_client.set_wmi_action(original_wmi_action)
        return jsonify({'status': 'wmi action insert successfully'})
    return jsonify({'status': 'can\'t assign action'})
