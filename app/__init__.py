from flask import Flask

app = Flask(__name__)
app.run(port=8090)

from app import routes
