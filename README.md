# 🎮 Proyecto Balance Game + Plataforma Web

Un juego inspirado en el caballo y animador James Baxter de hora de aventura, el que consiste en tratar de mantener el equilibrio de caballo encima de una pelota.

## 📌 Descripción del proyecto

Este proyecto consiste en un sistema completo compuesto por:

* 🎮 Un videojuego desarrollado en Unity
* 🌐 Una aplicación web desarrollada en React
* ⚙️ Un backend en Node.js con Express
* 🗄️ Base de datos en MongoDB Atlas

El objetivo del proyecto es permitir que los usuarios:

* Se registren e inicien sesión desde la web
* Jueguen al videojuego autenticados
* Guarden su progreso (puntajes y partidas)
* Consulten su información de perfil

El sistema funciona mediante una API REST que conecta el juego y la web con la base de datos.

---

# 🛠️ Tecnologías utilizadas

## 🎮 Juego (Unity)

* Unity (C#)
* UnityWebRequest (para consumir API)
* PlayerPrefs (almacenamiento local de sesión)

## 🌐 Frontend Web

* React
* TypeScript
* HTML / CSS
* Fetch / Axios (consumo de API)

## ⚙️ Backend

* Node.js
* Express
* JWT (autenticación)
* dotenv

## 🗄️ Base de datos

* MongoDB Atlas
* Mongoose

---

# 🔐 Funcionalidades principales

## 👤 Autenticación

* Registro de usuarios
* Login con JWT
* Persistencia de sesión

## 🎮 Juego

* Inicio de sesión desde Unity
* Guardado de puntaje
* Actualización de mejor puntaje
* Conteo de partidas jugadas

## 📊 Perfil de usuario

* Nombre
* Email
* Mejor puntaje
* Último puntaje
* Partidas jugadas

---

# ⚙️ Instalación del Backend

## 1. Descargar repositorio

Descargar el zip del repositorio desde el boton "<> code"

## 2. Instalar dependencias

```bash
npm install
```

## 3. Crear archivo .env

```env
PORT=3000
MONGO_URI=tu_uri_de_mongo
JWT_SECRET=tu_clave_secreta
```

## 4. Ejecutar servidor

```bash
npm run dev:server
```

Servidor disponible en:

```
http://localhost:3000/api
```

---

# 🌐 Instalación del Frontend (React)

## 1. Ejecutar proyecto

```bash
npm run dev
```

La aplicación se ejecutará en:

```
http://localhost:5173
```

---

# 🎮 Instalación del Juego (Unity)

## 1. Abrir el proyecto

* Abrir Unity Hub
* Seleccionar "Open Project"
* Elegir la carpeta del juego

## 2. Configurar URL de la API (por si queres cambiar la IP manualmente. Por defecto: localhost)

En el script `APIManager.cs`:

```csharp
private string URL_BASE = "http://localhost:3000/api/";
```

⚠️ Si usás otro dispositivo, reemplazar `localhost` por la IP local.

---

## 3. Ejecutar el juego

* Presionar Play en Unity
* O hacer build para PC

---

# 🔄 Flujo de funcionamiento

1. Usuario se registra / logea en la web
2. El backend genera un JWT
3. Unity usa ese JWT para autenticarse
4. El juego envía datos (puntaje, partidas)
5. El backend actualiza MongoDB
6. El usuario puede ver sus datos en la web

---

# ⚠️ Consideraciones

* El backend debe estar corriendo antes de usar el juego o la web
* Unity no funciona con `localhost` en dispositivos externos
* Asegurarse de que MongoDB Atlas permita conexiones

---

# 👨‍💻 Autor

Proyecto desarrollado por Tobias Noba como proyecto final de segundo año de una tecnicatura en desarrollo de software. Entregado en las materias: desarrollo de sistemas orientados a objetos (Juego Balance) y programción (Página web).

---

# 📄 Licencia

Uso educativo y demostrativo.
