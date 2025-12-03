# Nome da pasta do projeto
$folderName = "workshop-teste"
Write-Host "Iniciando setup do projeto: $folderName..."

# 1. Criar a pasta (se ela não existir)
if (-not (Test-Path -Path $folderName)) {
    Write-Host "Criando diretório: $folderName"
    New-Item -ItemType Directory -Name $folderName
} else {
    Write-Host "Diretório '$folderName' já existe. Acessando..."
}

# Bloco de segurança: Tenta executar os comandos dentro da pasta
try {
    # 2. Entrar na pasta
    Set-Location -Path $folderName

    # 3. Iniciar o projeto NPM
    Write-Host "Executando 'npm init -y'..."
    npm init -y
    
    # Verifica se o último comando (npm init) deu certo
    if (-not $?) { throw "Falha ao executar 'npm init -y'. Verifique se o NPM está instalado." }

    # 4. Instalar as dependências de desenvolvimento
    Write-Host "Instalando dependências (-D): typescript, @types/react, @types/react-dom..."
    npm install -D typescript @types/react @types/react-dom

    # 5. Feedback de sucesso (se o npm install deu certo)
    if ($?) {
        Write-Host "------------------------------------------------" -ForegroundColor Green
        Write-Host "SUCESSO! Projeto '$folderName' configurado." -ForegroundColor Green
        Write-Host "Dependências instaladas." -ForegroundColor Green
        Write-Host "------------------------------------------------"
    } else {
        # Se o $? for falso, o 'npm install' falhou
        throw "Falha ao instalar as dependências do NPM. Verifique o log acima."
    }
}
catch {
    # 6. Feedback de erro (captura qualquer 'throw' ou erro de comando)
    Write-Host "------------------------------------------------" -ForegroundColor Red
    Write-Host "ERRO! Ocorreu um problema no setup:" -ForegroundColor Red
    Write-Host $_.Exception.Message -ForegroundColor Red # Exibe a mensagem de erro
    Write-Host "------------------------------------------------"
}
finally {
    # Opcional: Só para garantir que você saia da pasta
    if (Test-Path ..) {
        Set-Location ..
        Write-Host "Script finalizado. Retornando ao diretório anterior."
    }
}

pause