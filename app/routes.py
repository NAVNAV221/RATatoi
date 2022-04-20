from app import app
from flask import jsonify

status = [
    {
        'WMI_SCOPE': "ROOT\\cimv2",
        'WMI_CLASS': 'Win32_OperatingSystem',
        'WMI_ATTRIBUTES': '*'
    }
]


@app.route('/')
@app.route('/api/device01/status', methods=['GET'])
def status_api():
    return jsonify(status)
