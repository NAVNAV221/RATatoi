from app import db

CLIENT_PROPERTIES = ['id', 'os_name', 'ip_address', 'wmi_actions']

client_wmiAction = db.Table('client_wmiAction',
                            db.Column('client_id', db.Integer, db.ForeignKey('client.id')),
                            db.Column('wmi_action_id', db.Integer, db.ForeignKey('wmi_action.id')))


class Client(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    os_name = db.Column(db.String(64), index=True)
    ip_address = db.Column(db.String(64), index=True, unique=True)
    wmi_action = db.relationship('WMIAction', secondary=client_wmiAction,
                                 primaryjoin=(client_wmiAction.c.client_id == id),
                                 backref='client_wmi_action')

    def to_dict(self):
        client_data = {
            'id': self.id,
            'os_name': self.os_name,
            'ip_address': self.ip_address,
        }
        return client_data

    def from_dict(self, client_data):
        for field in CLIENT_PROPERTIES:
            if field in client_data:
                setattr(self, field, client_data[field])

    def __repr__(self):
        return f'[User Description] {self.id} | {self.os_name} | {self.ip_address}'


class WMIAction(db.Model):
    id = db.Column(db.String(64), primary_key=True)
    wmi_class = db.Column(db.String(64), index=True, unique=True)
    wmi_attributes = db.Column(db.String(128), index=True)
    wmi_scope = db.Column(db.String(64), index=True)
