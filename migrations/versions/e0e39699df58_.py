"""empty message

Revision ID: e0e39699df58
Revises: d6f99a32b57d
Create Date: 2022-04-22 16:06:34.097166

"""
from alembic import op
import sqlalchemy as sa


# revision identifiers, used by Alembic.
revision = 'e0e39699df58'
down_revision = 'd6f99a32b57d'
branch_labels = None
depends_on = None


def upgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.drop_table('client_wmiAction')
    op.add_column('wmi_action', sa.Column('id', sa.String(length=64), nullable=False))
    op.drop_column('wmi_action', 'client_id')
    op.drop_column('wmi_action', 'action_id')
    # ### end Alembic commands ###


def downgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.add_column('wmi_action', sa.Column('action_id', sa.VARCHAR(length=64), nullable=False))
    op.add_column('wmi_action', sa.Column('client_id', sa.INTEGER(), nullable=True))
    op.drop_column('wmi_action', 'id')
    op.create_table('client_wmiAction',
    sa.Column('client_id', sa.INTEGER(), nullable=True),
    sa.Column('wmi_action_id', sa.INTEGER(), nullable=True),
    sa.ForeignKeyConstraint(['client_id'], ['client.id'], ),
    sa.ForeignKeyConstraint(['wmi_action_id'], ['wmi_action.id'], )
    )
    # ### end Alembic commands ###
