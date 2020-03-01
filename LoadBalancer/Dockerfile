FROM nginx
EXPOSE 80
EXPOSE 443

RUN apt-get update
RUN apt-get install -y software-properties-common
RUN apt-get install -y python-certbot-nginx

RUN rm /etc/nginx/conf.d/*
RUN rm /etc/nginx/nginx.conf

COPY proxy.conf /etc/nginx/conf.d/
COPY nginx.conf /etc/nginx/
COPY tcpconf.conf /etc/nginx/tcpconf.d/
COPY getcerts.sh /etc/nginx/

WORKDIR /etc/nginx
RUN chmod +x getcerts.sh