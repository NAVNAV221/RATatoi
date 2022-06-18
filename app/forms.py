from flask_wtf import FlaskForm
from wtforms import StringField, SubmitField, SelectField
from wtforms.validators import DataRequired
from wtforms_sqlalchemy.fields import QuerySelectField
from app.models import WMIAction, Client


class RegisterWMIAction(FlaskForm):
    wmi_class = StringField('WMI Class', validators=[DataRequired()])
    wmi_attributes = StringField('WMI Attributes', validators=[DataRequired()])
    wmi_scope = StringField('WMI Scope', validators=[DataRequired()])
    submit = SubmitField('Register WMI')


def wmi_choice_query():
    return WMIAction.query


def client_id_query():
    return Client.query


class AssignClientAction(FlaskForm):
    client_id_opts = QuerySelectField(query_factory=client_id_query, allow_blank=True)
    wmi_actions_opts = QuerySelectField(query_factory=wmi_choice_query, allow_blank=True)
    submit = SubmitField('Assign WMI action')
