# estágio de compilação
FROM node:9-alpine as build-env
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# estágio de produção
FROM nginx:alpine
COPY --from=build-env /app/dist /usr/share/nginx/html/dist
COPY --from=build-env /app/index.html /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]