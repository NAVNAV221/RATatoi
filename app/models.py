from app import db


class Client(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    os_name = db.Column(db.String(64), index=True, unique=True)
    ip_address = db.Column(db.String(64), index=True, unique=True)

    def __repr__(self):
        return f'[User Description] {self.id} | {self.os_name} | {self.ip_address}'
