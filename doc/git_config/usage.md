#Configuración y comandos git

#Configuración inicial 

1. Clonar -> git clone https://bitbucket.org/NormanColoma/dss
2. Configurar usuario -> git config --global user.name "Nombre" 
			 git config --global user.email "Email" 
3. Añadir el repositiorio -> git remote add origin https://bitbucket.org/NormanColoma/dss


## Comandos git

######Estado, cambios y commit 

**_git status_:** Para consultar los archivos pendientes de commit tras realizar cambios en ellos (rojo sin añadir, verde añadidos pendiende de commit)
**_git add ._:** Añadir todos los archivos pendientes de commit. 
**_git commit -m_:** Para realizar el commit  -> git commit -m "Mensaje commit" 
**_git add -a -m_:** Añadir y commiter a la vez -> git commit -a -m "Mensaje commit"
**_git commit --amend_:** Para editar el mensaje del último commit

######Ramas 

**_git branch_:** Consultar la rama actual
**_git checkout_:** Cambiar de rama -> git checkout rama
**_git checkout -b_:**  Crear una nueva rama -> git checkout -b nueva_rama 
**_git branch -d_:** Borrado de una rama -> git branch -d rama 

######Mergeos 

**_git merge --no-ff_:** Para mergear una rama a otra: 
				1. Primero vamos a la rama donde queremos mergear -> git checkout rama_merge 
				2. Después realizamos el merge -> git merge --no-ff rama_a_mergear -m "Mensaje" (El -m es opcional) 

######Repositiorios 

**_git remote add_:** Para añadir repositorios -> git remote add alias enlace_repositorio 

######Pull y push 
**_git pull_:** Actualizar repositorio local, con los cambios realizados en el repositorio remoto -> git pull rama nombre_repo(rama en concreto) o git pull --all nombre_repo (todas las ramas)
**_git push_:** Subir los cambios al repositorio -> Antes de hacer push, siempre pull, y después push -> git push rama nombre_repo (rama en concreto) o git push --all nombre_repo (para todas las ramas)







