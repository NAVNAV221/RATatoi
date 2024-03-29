"""WMIAction tables created

Revision ID: a0f3270c6e09
Revises: 
Create Date: 2022-04-22 00:40:34.823563

"""
from alembic import op
import sqlalchemy as sa


# revision identifiers, used by Alembic.
revision = 'a0f3270c6e09'
down_revision = None
branch_labels = None
depends_on = None


def upgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.create_table('wmi_action',
    sa.Column('action_id', sa.String(length=64), nullable=False),
    sa.Column('wmi_class', sa.String(length=64), nullable=True),
    sa.Column('wmi_attributes', sa.String(length=128), nullable=True),
    sa.Column('wmi_scope', sa.String(length=64), nullable=True),
    sa.PrimaryKeyConstraint('action_id')
    )
    op.create_index(op.f('ix_wmi_action_wmi_attributes'), 'wmi_action', ['wmi_attributes'], unique=True)
    op.create_index(op.f('ix_wmi_action_wmi_class'), 'wmi_action', ['wmi_class'], unique=True)
    op.create_index(op.f('ix_wmi_action_wmi_scope'), 'wmi_action', ['wmi_scope'], unique=True)
    # ### end Alembic commands ###


def downgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.drop_index(op.f('ix_wmi_action_wmi_scope'), table_name='wmi_action')
    op.drop_index(op.f('ix_wmi_action_wmi_class'), table_name='wmi_action')
    op.drop_index(op.f('ix_wmi_action_wmi_attributes'), table_name='wmi_action')
    op.drop_table('wmi_action')
    # ### end Alembic commands ###
