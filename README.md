# FeatherCli

Official CLI for FeatherPanel.

## Migrate from Pterodactyl

### Local install

```bash
feathercli config setup
feathercli migrate --pterodactyl-dir /var/www/pterodactyl
```

### Docker / SQL dump

```bash
docker compose exec database mariadb-dump -u root -p"$MARIADB_ROOT_PASS" panel > panel.sql
docker compose exec panel cat /app/var/.env > panel.env

feathercli migrate \
  --sql-dump ./panel.sql \
  --env-file ./panel.env \
  --staging-db-host 127.0.0.1 \
  --staging-db-user root \
  --staging-db-password 'your-mysql-password'
```

`--app-key` can be used instead of `--env-file`.

| Flag | Purpose |
|------|---------|
| `--sql-dump` | Pterodactyl `.sql` dump |
| `--env-file` | Panel `.env` (needs `APP_KEY`) |
| `--app-key` | `APP_KEY` only |
| `--staging-db-*` | MySQL used to load the dump |
| `--pterodactyl-dir` | Local install path |
