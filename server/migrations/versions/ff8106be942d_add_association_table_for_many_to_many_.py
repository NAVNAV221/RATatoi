"""Add association table for many-to-many connection

Revision ID: ff8106be942d
Revises: e0e39699df58
Create Date: 2022-04-22 16:08:55.676166

"""
from alembic import op
import sqlalchemy as sa


# revision identifiers, used by Alembic.
revision = 'ff8106be942d'
down_revision = 'e0e39699df58'
branch_labels = None
depends_on = None


def upgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.drop_column('wmi_action', 'client_id')
    # ### end Alembic commands ###


def downgrade():
    # ### commands auto generated by Alembic - please adjust! ###
    op.add_column('wmi_action', sa.Column('client_id', sa.INTEGER(), nullable=True))
    # ### end Alembic commands ###