---

## 📗 `API_Structure.md`

```markdown
# 📚 VaultEdge API Documentation

This document describes the API endpoints of the VaultEdge backend system and their functions.

---

## 🔐 AuthController

| Endpoint | Method | Description |
|--------------------|------|--------------------------|
| `/api/auth/login` | POST | User login |
| `/api/auth/register` | POST | New user registration|
| `/api/auth/refresh` | POST | Token renewal |

---

## 🗄️ VaultController

| Endpoint | Method | Description |
|--------------------------|-------|---------------------------------|
| `/api/vault/{userId}` | GET | User vault items |
| `/api/vault` | POST | Add new vault item |
| `/api/vault/{id}` | PUT | Update Vault item |
| `/api/vault/{id}` | DELETE| Delete Vault item |

---

## 👤 UserController

| Endpoint | Method | Description |
|--------------------|------|----------------------|
| `/api/user/{id}` | GET | User information |
| `/api/user` | GET | Show all users|

---

## 📦 Response Format

```json
{
"success": true,
"message": "OK",
"data": { ... }
}