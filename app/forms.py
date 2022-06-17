from flask_wtf import FlaskForm
from wtforms import StringField, SubmitField, SelectField
from wtforms.validators import DataRequired


class RegisterWMIAction(FlaskForm):
    wmi_class = StringField('WMI Class', validators=[DataRequired()])
    wmi_attributes = StringField('WMI Attributes', validators=[DataRequired()])
    wmi_scope = StringField('WMI Scope', validators=[DataRequired()])
    submit = SubmitField('Register WMI')


class AssignClientAction(FlaskForm):
    client_id = SelectField('Client ID', validators=[DataRequired()])
    pass
