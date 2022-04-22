from app import db

CLIENT_PROPERTIES = ['id', 'os_name', 'ip_address', 'wmi_actions']


class Client(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    os_name = db.Column(db.String(64), index=True, unique=True)
    ip_address = db.Column(db.String(64), index=True, unique=True)
    wmi_actions = db.relationship('WMIAction', backref='client', lazy='dynamic')

    def to_dict(self):
        client_data = {
            'id': self.id,
            'os_name': self.os_name,
            'ip_address': self.ip_address,
            'wmi_actions': self.wmi_actions
        }
        return client_data

    def from_dict(self, client_data):
        for field in CLIENT_PROPERTIES:
            if field in client_data:
                setattr(self, field, client_data[field])

    def __repr__(self):
        return f'[User Description] {self.id} | {self.os_name} | {self.ip_address} | {self.wmi_actions}'


class WMIAction(db.Model):
    action_id = db.Column(db.String(64), primary_key=True)
    wmi_class = db.Column(db.String(64), index=True, unique=True)
    wmi_attributes = db.Column(db.String(128), index=True, unique=True)
    wmi_scope = db.Column(db.String(64), index=True, unique=True)
    client_id = db.Column(db.Integer, db.ForeignKey('client.id'))
