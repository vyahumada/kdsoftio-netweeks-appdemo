FROM nginx:1.15-alpine

# Install bash
RUN apk add --update bash && rm -rf /var/cache/apk/*

## Remove default nginx website
RUN rm -rf /usr/share/nginx/html/*

## Copy website files
COPY nginx.conf /etc/nginx/nginx.conf
COPY app/ /usr/share/nginx/html

## Copy default nginx config
COPY nginx.conf /etc/nginx/conf.d/default.conf

CMD ["nginx", "-g", "daemon off;"]