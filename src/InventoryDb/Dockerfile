FROM mongo:4.4.10-focal

COPY dump/ /dump/
COPY mongo.sh .
RUN chmod 777 mongo.sh

CMD ["/mongo.sh"]