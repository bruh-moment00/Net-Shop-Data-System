export default function authHeader() {
  const userStr = localStorage.getItem("token");
  let user = null;
  if (userStr) user = JSON.parse(userStr);

  if (user) {
    return "Bearer " + user;
  } else {
    return "";
  }
}
