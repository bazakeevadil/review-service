import React from 'react'
import { NavLink } from 'react-router-dom'
import { NumberSchema } from 'yup'

const Header = () => {

    const token = true
    return (
        <>
            <header className='header'>

                <div className='container'>
                    <div className='header__wrapper'>
                       <NavLink to='/'>
                       <div className='header__logo'>
                            <img src='https://static.tildacdn.com/tild6137-3639-4364-a233-316662356666/Asset_7logo.png' />
                        </div>
                       </NavLink>
                        {token ?
                            <div className='header__isAuth'>
                                <div className='header__links'>
                                <NavLink to='/' className='header__link1'>Главная</NavLink>
                                 <NavLink to='/courses' className='header__link2'>Курсы</NavLink>
                        
                                </div>
                                <div className='header__user'>
                                    <img src='https://icons.veryicon.com/png/o/internet--web/prejudice/user-128.png' />
                                </div>
                            </div> :
                            <div className="header__login">
                                <NavLink to='/login'>
                                    <button >
                                        Войти
                                    </button>
                                </NavLink>
                                <NavLink to='/registration'>
                                    <button >
                                        Регистрация
                                    </button>
                                </NavLink>
                            </div>
                        }

                    </div>
                </div>
            </header>
        </>
    )
}

export default Header