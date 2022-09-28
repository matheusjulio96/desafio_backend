const PROXY_CONFIG = [
  {
    context: [
      "/api",
    ],
    target: "http://localhost:5194",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
